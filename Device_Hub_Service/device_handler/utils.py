from channels.layers import get_channel_layer
import json

import device_handler.consumers
from iot_hub.models import IoTDevice, Function
from .models import WSConnection


def call_function(device: IoTDevice, function: Function, params):
    channel_name = WSConnection.objects.get(device=device).channel_name
    function_name = Function.name
    channel_layer = get_channel_layer()
    await channel_layer.send()


