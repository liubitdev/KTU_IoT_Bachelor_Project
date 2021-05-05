from channels.generic.websocket import JsonWebsocketConsumer
from device_handler.utils import registerDevice
from iot_hub.models import ThingDevice, ControllerDevice


class IoTRegisterConsumer(JsonWebsocketConsumer):
    def receive_json(self, content, **kwargs):
        device = registerDevice(content)
        response = []
        if isinstance(device, ControllerDevice):
            response['result'] = "New Controller Registered."
        elif isinstance(device, ThingDevice):
            response['result'] = "New Thing Registered."
        else:
            response['result'] = "Registration unsuccessful, check JSON syntax."


class IoTLoginConsumer(JsonWebsocketConsumer):
    pass


class IoTPollConsumer(JsonWebsocketConsumer):
    async def websocket_connect(self, message):
        user = self.scope["user"]
        await self.accept()
