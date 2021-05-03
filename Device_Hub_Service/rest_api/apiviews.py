from rest_framework import viewsets

from iot_hub.models import ControllerDevice, State, ThingDevice, Function, Parameter, Behavior, StateTrigger, DateTrigger
from rest_api.serializers import ControllerDeviceSerializer, StateSerializer, ThingDeviceSerializer, FunctionSerializer, \
    ParameterSerializer, BehaviorSerializer, StateTriggerSerializer, DateTriggerSerializer


class ControllerDeviceViewSet(viewsets.ModelViewSet):
    queryset = ControllerDevice.objects.all()
    serializer_class = ControllerDeviceSerializer


class StateViewSet(viewsets.ModelViewSet):
    queryset = State.objects.all()
    serializer_class = StateSerializer


class ThingDeviceViewSet(viewsets.ModelViewSet):
    queryset = ThingDevice.objects.all()
    serializer_class = ThingDeviceSerializer


class FunctionViewSet(viewsets.ModelViewSet):
    queryset = Function.objects.all()
    serializer_class = FunctionSerializer


class ParameterViewSet(viewsets.ModelViewSet):
    queryset = Parameter.objects.all()
    serializer_class = ParameterSerializer


class BehaviorViewSet(viewsets.ModelViewSet):
    queryset = Behavior.objects.all()
    serializer_class = BehaviorSerializer


class StateTriggerViewSet(viewsets.ModelViewSet):
    queryset = StateTrigger.objects.all()
    serializer_class = StateTriggerSerializer


class DateTriggerViewSet(viewsets.ModelViewSet):
    queryset = DateTrigger.objects.all()
    serializer_class = DateTriggerSerializer


