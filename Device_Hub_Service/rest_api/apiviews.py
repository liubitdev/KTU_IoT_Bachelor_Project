from rest_framework import viewsets

from iot_hub.models import \
    IoTDevice, \
    ControllerDevice, \
    State, \
    ThingDevice, \
    Function, \
    Parameter, \
    Behavior, \
    Call, \
    CallParameter, \
    StateTriggerSpecific, \
    StateTriggerRange, \
    DateTrigger

from rest_api.serializers import \
    IoTDeviceSerializer, \
    ControllerDeviceSerializer, \
    StateSerializer, \
    ThingDeviceSerializer, \
    FunctionSerializer, \
    ParameterSerializer, \
    BehaviorSerializer, \
    CallSerializer, \
    CallParameterSerializer, \
    StateTriggerSpecificSerializer, \
    StateTriggerRangeSerializer, \
    DateTriggerSerializer


class IoTDeviceViewSet(viewsets.ModelViewSet):
    queryset = IoTDevice.objects.all()
    serializer_class = IoTDeviceSerializer


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


class CallViewSet(viewsets.ModelViewSet):
    queryset = Call.objects.all()
    serializer_class = CallSerializer


class CallParameterViewSet(viewsets.ModelViewSet):
    queryset = CallParameter.objects.all()
    serializer_class = CallParameterSerializer


class StateTriggerSpecificViewSet(viewsets.ModelViewSet):
    queryset = StateTriggerSpecific.objects.all()
    serializer_class = StateTriggerSpecificSerializer


class StateTriggerRangeViewSet(viewsets.ModelViewSet):
    queryset = StateTriggerRange.objects.all()
    serializer_class = StateTriggerRangeSerializer


class DateTriggerViewSet(viewsets.ModelViewSet):
    queryset = DateTrigger.objects.all()
    serializer_class = DateTriggerSerializer
