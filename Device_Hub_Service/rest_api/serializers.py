from rest_framework import serializers

from iot_hub.models import \
    IoTDevice,\
    ControllerDevice,\
    State,\
    ThingDevice,\
    Function,\
    Parameter,\
    Behavior,\
    Call,\
    CallParameter,\
    Trigger,\
    StateTrigger,\
    StateTriggerSpecific,\
    StateTriggerRange,\
    DateTrigger


class IoTDeviceSerializer(serializers.Serializer):
    class Meta:
        model = IoTDevice
        fields = '__all__'


class ControllerDeviceSerializer(IoTDeviceSerializer, serializers.HyperlinkedModelSerializer):
    class Meta:
        model = ControllerDevice


class StateSerializer(serializers.HyperlinkedModelSerializer):
    class Meta:
        model = State
        fields = '__all__'


class ThingDeviceSerializer(IoTDeviceSerializer, serializers.HyperlinkedModelSerializer):
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


class CallSerializer(serializers.HyperlinkedModelSerializer):
    class Meta:
        model = Call
        fields = '__all__'


class CallParameterSerializer(serializers.HyperlinkedModelSerializer):
    class Meta:
        model = CallParameter
        fields = '__all__'


class TriggerSerializer(serializers.Serializer):
    class Meta:
        model = Trigger
        fields = '__all__'
        abstract = True


class StateTriggerSerializer(TriggerSerializer):
    class Meta:
        model = StateTrigger
        fields = TriggerSerializer.Meta.fields + 'state'
        abstract = True


class StateTriggerSpecificSerializer(StateTriggerSerializer, serializers.HyperlinkedModelSerializer):
    class Meta:
        model = StateTriggerSpecific
        fields = StateTriggerSerializer.Meta.fields + 'trigger_value'


class StateTriggerRangeSerializer(StateTriggerSerializer, serializers.HyperlinkedModelSerializer):
    class Meta:
        model = StateTriggerRange
        fields = StateTriggerSerializer.Meta.fields + 'trigger_from' + 'trigger_to'


class DateTriggerSerializer(TriggerSerializer, serializers.HyperlinkedModelSerializer):
    class Meta:
        model = DateTrigger
        fields = TriggerSerializer.Meta.fields + 'when'