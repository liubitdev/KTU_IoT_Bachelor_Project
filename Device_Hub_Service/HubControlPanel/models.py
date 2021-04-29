from django.db import models

# Create your models here.
class Device_Model(models.Model):
    name = models.TextField(blank=False, null=False)
    message = models.TextField(blank=True, null=True)
    
# class Rule_Model(models.Model):
    # code = models.TextField(blank=False, null=False)
    

