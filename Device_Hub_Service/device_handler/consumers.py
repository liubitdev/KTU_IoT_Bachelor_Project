from asgiref.sync import async_to_sync
from channels.generic.websocket import AsyncJsonWebsocketConsumer, WebsocketConsumer
from django.contrib.auth.models import AnonymousUser

from device_handler.models import WSConnection
from iot_hub.models import IoTDevice


# class DeviceConsumer(AsyncJsonWebsocketConsumer):
#     def connect(self):
#
#
#     def websocket_connect(self, message):
#         pass
#         # if isinstance(self.scope["user"], AnonymousUser):
#         #     self.close(code=401)
#         # else:
#         #     device = IoTDevice.objects.get(device_user=self.scope["user"])
#         #     WSConnection.objects.create(channel_name=self.channel_name, device=device)
#
#     def websocket_disconnect(self, message):
#         pass
#         # WSConnection.objects.filter(channel_name=self.channel_name).delete()

class RebroadcastConsumer(WebsocketConsumer):

    def connect(self):
        self.accept()
        async_to_sync(self.channel_layer.group_add)("devices", self.channel_name)


    def receive(self, text_data=None, bytes_data=None):
        async_to_sync(self.channel_layer.group_send)(
            "devices",
            {
              "type": "send.to.devices",
              "text": text_data,
            },
        )

    def send_to_devices(self, event):
        self.send(text_data=event["text"])

    def disconnect(self, code):
        async_to_sync(self.channel_layer.group_discard)("devices", self.channel_name)