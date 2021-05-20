from django.db import models


class WSConnection(models.Model):
    """
    Describes an active WebSocket Consumer connection with an IoTDevice. Holds the channel name and foreign key
    to the connected device.
    """
    channel_name = models.TextField()
    device = models.ForeignKey("iot_hub.IoTDevice", on_delete=models.CASCADE)
