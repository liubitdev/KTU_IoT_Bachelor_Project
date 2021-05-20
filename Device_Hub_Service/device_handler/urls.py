from channels.routing import URLRouter
from django.urls import path

from iot_hub.middleware import JWTAuthMiddlewareStack
#from .consumers import DeviceConsumer
from .consumers import RebroadcastConsumer

# websocket_patterns = JWTAuthMiddlewareStack(
#     URLRouter(
#         [path("ws/", DeviceConsumer.as_asgi())]
#     )
# )

websocket_patterns = URLRouter([path("ws/", RebroadcastConsumer.as_asgi())])