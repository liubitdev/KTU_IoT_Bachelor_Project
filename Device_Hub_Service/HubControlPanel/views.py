from django.shortcuts import render
from django.http import HttpResponse

from .models import Device_Model

# Create your views here.

def Hub_Control_Panel_View(request, *args, **kwargs):
    querySet = Device_Model.objects.all();
    context = {
        "deviceList" : querySet
    }
    return render(request, 'index.html', context)