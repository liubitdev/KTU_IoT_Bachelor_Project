from django.shortcuts import render

from .models import ThingDevice, ControllerDevice


def hub_control_panel_view(request, *args, **kwargs):
    context = {
        "things": ThingDevice.objects.all(),
        "controllers": ControllerDevice.objects.all()
    }
    return render(request, 'index.html', context)