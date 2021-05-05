from channels.generic.websocket import JsonWebsocketConsumer


class DeviceConsumer(JsonWebsocketConsumer):
    async def websocket_connect(self, message):
        user = self.scope["user"]
        await self.accept()


class EchoConsumer(JsonWebsocketConsumer):
    async def websocket_connect(self, message):
        user = self.scope["user"]
        await self.accept()

    async def receive_json(self, content, **kwargs):
        self.send_json(content)