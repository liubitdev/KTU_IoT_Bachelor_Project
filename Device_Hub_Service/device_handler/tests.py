from channels.testing import WebsocketCommunicator
from django.test import TestCase
from .consumers import DeviceConsumer, EchoConsumer


# class DeviceConsumerTestCase(TestCase):
#     async def test_consumer(self):
#         communicator = WebsocketCommunicator(DeviceConsumer.as_asgi(), "/api/poll/")
#         connected, subprotocol = await communicator.connect()
#         assert connected
#         await communicator.send_to(text_data="hello")
#         response = await communicator.receive_from()
#         assert response == "hello"
#         await communicator.disconnect()


# class EchoConsumerTestCase(TestCase):
#     async def test_consumer(self):
#         communicator = WebsocketCommunicator(DeviceConsumer.as_asgi(), "/api/echo/")
#         connected, subprotocol = await communicator.connect()
#         assert connected
#         await communicator.send_to(text_data="hello")
#         response = await communicator.receive_from()
#         assert response == "hello"
#         await communicator.disconnect()
