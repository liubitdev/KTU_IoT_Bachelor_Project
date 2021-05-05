from channels.routing import URLRouter
from django.urls import path
from iot_hub.middleware import JWTAuthMiddlewareStack
from .consumers import IoTRegisterConsumer,\
    IoTLoginConsumer,\
    IoTPollConsumer


websocket_patterns = JWTAuthMiddlewareStack(URLRouter([
    path("", IoTPollConsumer.as_asgi())
]))