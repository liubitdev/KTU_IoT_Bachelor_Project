from django.contrib import admin

from .models import \
    ControllerDevice, \
    State, \
    ThingDevice, \
    Function, \
    Parameter, \
    Behavior, \
    Call, \
    CallParameter, \
    StateTriggerSpecific, \
    StateTriggerRange, \
    DateTrigger

admin.site.register(ControllerDevice)
admin.site.register(State)
admin.site.register(ThingDevice)
admin.site.register(Function)
admin.site.register(Parameter)
admin.site.register(Behavior)
admin.site.register(Call)
admin.site.register(CallParameter)
admin.site.register(StateTriggerSpecific)
admin.site.register(StateTriggerRange)
admin.site.register(DateTrigger)
