from django.db import models


class IoTDevice(models.Model):
    name = models.TextField()
    registered_at = models.DateTimeField(auto_now_add=True)
    verified_at = models.DateTimeField(blank=True, null=True)
    verified_by = models.ForeignKey("auth.User", on_delete=models.CASCADE, null=True)
    last_seen = models.DateTimeField()

    class Meta:
        abstract = True


class ControllerDevice(IoTDevice):
    pass


class State(models.Model):
    device = models.ForeignKey("ControllerDevice", on_delete=models.CASCADE)
    name = models.TextField()
    value = models.TextField()


class ThingDevice(IoTDevice):
    pass


class Function(models.Model):
    device = models.ForeignKey("ThingDevice", on_delete=models.CASCADE)
    name = models.TextField()


class Parameter(models.Model):
    function = models.ForeignKey("Function", on_delete=models.CASCADE)
    order = models.IntegerField()
    type = models.TextField()


class Behavior(models.Model):
    created_by = models.ForeignKey("auth.User", on_delete=models.CASCADE)


class Trigger(models.Model):
    behavior = models.ForeignKey("Behavior", on_delete=models.CASCADE)

    class Meta:
        abstract = True


class StateTrigger(Trigger):
    state = models.ForeignKey("State", on_delete=models.CASCADE)


class DateTrigger(Trigger):
    when = models.DateTimeField()
