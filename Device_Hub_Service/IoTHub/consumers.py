from channels.generic.websocket import JsonWebsocketConsumer
from .utils import registerDevice
from .models import ThingDevice, ControllerDevice


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



class IoTPollConsumer(JsonWebsocketConsumer):
    async def websocket_connect(self, message):
        user = self.scope["user"]
        await self.accept()
