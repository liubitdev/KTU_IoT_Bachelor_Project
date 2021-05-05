from channels.routing import URLRouter
from django.urls import path
from iot_hub.middleware import JWTAuthMiddlewareStack
from .consumers import DeviceConsumer, EchoConsumer


websocket_patterns = (URLRouter([
    path("api/poll/", DeviceConsumer.as_asgi()),
    path("api/echo/", EchoConsumer.as_asgi())
]))