from django.shortcuts import render

from iot_hub.models import ThingDevice, ControllerDevice


def user_control_panel(request, *args, **kwargs):
    context = {
        "things": ThingDevice.objects.all(),
        "controllers": ControllerDevice.objects.all()
    }
    return render(request, 'index.html', context)