"""
ASGI config for iot_hub project.

It exposes the ASGI callable as a module-level variable named ``application``.

For more information on this file, see
https://docs.djangoproject.com/en/3.2/howto/deployment/asgi/
"""

import os

from channels.routing import ProtocolTypeRouter
from django.core.asgi import get_asgi_application

import device_handler.urls

os.environ.setdefault('DJANGO_SETTINGS_MODULE', 'iot_hub.settings')

application = ProtocolTypeRouter({
    "http": get_asgi_application(),
    "websocket": device_handler.urls.websocket_patterns
})
