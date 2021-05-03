from rest_framework import serializers

from iot_hub.models import \
    IoTDevice,\
    ControllerDevice,\
    State,\
    ThingDevice,\
    Function,\
    Parameter,\
    Behavior,\
    Trigger,\
    StateTrigger,\
    DateTrigger


class IoTDeviceSerializer(serializers.Serializer):
    class Meta:
        fields = '__all__'


class ControllerDeviceSerializer(IoTDeviceSerializer):
    class Meta:
        model = ControllerDevice


class StateSerializer(serializers.HyperlinkedModelSerializer):
    class Meta:
        model = State
        fields = '__all__'


class ThingDeviceSerializer(IoTDeviceSerializer):
    class Meta:
        model = ThingDevice


class FunctionSerializer(serializers.HyperlinkedModelSerializer):
    class Meta:
        model = Function
        fields = '__all__'


class ParameterSerializer(serializers.HyperlinkedModelSerializer):
    class Meta:
        model = Parameter
        fields = '__all__'


class BehaviorSerializer(serializers.HyperlinkedModelSerializer):
    class Meta:
        model = Behavior
        fields = '__all__'


class TriggerSerializer(serializers.HyperlinkedModelSerializer):
    class Meta:
        fields = '__all__'


class StateTriggerSerializer(TriggerSerializer):
    class Meta:
        model = StateTrigger
        fields = TriggerSerializer.Meta.fields + 'state'


class DateTriggerSerializer(TriggerSerializer):
    class Meta:
        model = DateTrigger
        fields = TriggerSerializer.Meta.fields + 'when'

