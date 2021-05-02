from django.db import models


class IoTDevice(models.Model):
    name = models.TextField()


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
    pass


class Trigger(models.Model):
    behavior = models.ForeignKey("Behavior", on_delete=models.CASCADE)


class StateTrigger(models.Model):
    state = models.ForeignKey("State", on_delete=models.CASCADE)


class DateTrigger(models.Model):
    when = models.DateTimeField()
