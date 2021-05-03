from django.contrib import admin

from .models import  \
    IoTDevice,\
    ControllerDevice,\
    State,\
    ThingDevice,\
    Function,\
    Parameter,\
    Behavior,\
    Trigger,\
    StateTrigger,\
    DateTrigger

admin.site.register(ControllerDevice)
admin.site.register(State)
admin.site.register(ThingDevice)
admin.site.register(Function)
admin.site.register(Parameter)
admin.site.register(Behavior)
admin.site.register(StateTrigger)
admin.site.register(DateTrigger)
