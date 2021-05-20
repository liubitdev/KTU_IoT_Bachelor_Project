from django.db import models
from datetime import datetime

from django.core.validators import \
    MinValueValidator, \
    MaxValueValidator, \
    RegexValidator


class IoTDevice(models.Model):
    """
    Abstract class for an IoT Device. Can be a ControllerDevice or a ThingDevice.
    Has a linked user account, name, DateTimes marking creation and verification dates.
    """
    device_user = models.OneToOneField("auth.User", on_delete=models.CASCADE, related_name="+")
    name = models.TextField()
    registered_at = models.DateTimeField(auto_now_add=True)
    verified_at = models.DateTimeField(blank=True, null=True, default="False")
    verified_by = models.ForeignKey("auth.User", on_delete=models.CASCADE, null=True, related_name="+")
    last_seen = models.DateTimeField(auto_now=True)


class ControllerDevice(IoTDevice):
    """
    Concrete IoTDevice subclass, can have States.
    """
    pass


class State(models.Model):
    """
    Stores different kinds of sensory or state data from a ControllerDevice. States have a name and value.
    """
    device = models.ForeignKey("ControllerDevice", on_delete=models.CASCADE)
    name = models.TextField()
    value = models.TextField()


class ThingDevice(IoTDevice):
    """
    Concrete IoTDevice subclass, can have Functions and Parameters.
    """
    pass


class Function(models.Model):
    """
    Correlates to an actual function on the ThingDevice. Functions have a name and may have one or several Parameters.
    """
    device = models.ForeignKey("ThingDevice", on_delete=models.CASCADE)
    name = models.TextField()


class Parameter(models.Model):
    """
    Correlates to a single Parameter of a Function. Has a foreign key to the Function.
    The order field marks which (first, second, etc.) order this parameter goes into a function call.
    The order must be in the range [1;10]. The type fields marks the .NET name of the parameter value type.
    """
    function = models.ForeignKey("Function", on_delete=models.CASCADE)
    order = models.IntegerField(validators=[
        MinValueValidator(1, "Parameter order values must be at least 1<=."),
        MaxValueValidator(10, "Parameter order values must be <=10.")
    ])
    type = models.TextField()


class Behavior(models.Model):
    """
    Identifies a specific behavior, allowing to setup ThingDevice function calls when tripped by a Trigger.
    """
    created_by = models.ForeignKey("auth.User", on_delete=models.CASCADE)
    call_cooldown = models.DurationField()
    last_called = models.DateTimeField(editable=False)

    def initiate_calls(self, trigger):
        # Check if cooldown period has passed
        if (self.last_called + self.call_cooldown).date() < datetime.now():
            for c in self.call_set.get_queryset():
                c.call()

        self.last_called = datetime.now()
        self.save()


class Call(models.Model):
    """
    Describes a Function call, linking a behavior and function.
    """
    behavior = models.ForeignKey("Behavior", on_delete=models.CASCADE)
    function = models.ForeignKey("Function", on_delete=models.CASCADE)

    def call(self):
        func_params = self.function.parameter_set.get_queryset()
        device_handler.utils.call_function()


class CallParameter(models.Model):
    """
    Describes a specific parameter of a call, has links to the Call parent and the Parameter object that is being
    referenced as well as the actual value.
    """
    call = models.ForeignKey("Call", on_delete=models.CASCADE)
    parameter = models.ForeignKey("Parameter", on_delete=models.CASCADE)
    value = models.TextField()


class Trigger(models.Model):
    """
    An abstract class for defining behavior triggers for function calls. All triggers belong to some sort of Behavior.
    """
    behavior = models.ForeignKey("Behavior", on_delete=models.CASCADE)

    class Meta:
        abstract = True

    def trigger(self):
        self.behavior.initiate_calls(self)


class StateTrigger(Trigger):
    """
    An abstract class for defining State-based triggers, that depend on a State value.
    """
    state = models.ForeignKey("State", on_delete=models.CASCADE)

    class Meta:
        abstract = True

    def check_state(self, sender, instance, **kwargs):
        pass

    @classmethod
    def __init_subclass__(cls, **kwargs):
        super().__init_subclass__(**kwargs)
        models.signals.pre_save.connect(cls.check_state, sender=State)


class StateTriggerSpecific(StateTrigger):
    """
    A StateTrigger that triggers on a specific value.
    """
    trigger_value = models.TextField()

    def check_state(self, sender, instance, *args, **kwargs):
        if instance != self.state:
            pass
        previous_value = State.objects.get(instance.pk).value
        if previous_value != instance.value and instance.value == self.trigger_value:
            self.trigger()


class StateTriggerRange(StateTrigger):
    """
    A StateTrigger that triggers on a value range.
    """
    # Validators here check if numbers are either integers or float values, either positive or negative.
    trigger_from = models.TextField(validators=[RegexValidator(regex=r"^-?[0-9]+(.[0-9]+)?$")])
    trigger_to = models.TextField(validators=[RegexValidator(regex=r"^-?[0-9]+(.[0-9]+)?$")])

    def check_state(self, sender, instance, *args, **kwargs):
        if instance != self.state:
            pass
        previous_value = State.objects.get(instance.pk).value
        if previous_value != instance.value:
            if self.trigger_from <= instance.value and instance.value >= self.trigger_to:
                self.trigger()


class DateTrigger(Trigger):
    """
    A Trigger that triggers on a specific date.
    """
    when = models.DateTimeField()
