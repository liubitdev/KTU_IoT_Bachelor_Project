from datetime import datetime

from channels.routing import URLRouter
from django.contrib.auth.models import AnonymousUser
from django.test import TestCase

from rest_api.serializers import ControllerDeviceSerializer
from .middleware import JWTAuthMiddlewareStack
from iot_hub.models import\
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


class IoTDeviceTestCase(TestCase):
    def setUp(self):
        pass

    def test_labels(self):
        self.assertEqual(IoTDevice._meta.get_field('name').verbose_name, "name")
        self.assertEqual(IoTDevice._meta.get_field('registered_at').verbose_name, "registered at")
        self.assertEqual(IoTDevice._meta.get_field('verified_at').verbose_name, "verified at")
        self.assertEqual(IoTDevice._meta.get_field('verified_by').verbose_name, "verified by")
        self.assertEqual(IoTDevice._meta.get_field('last_seen').verbose_name, "last seen")


class ControllerDeviceTestCase(TestCase):
    def setUp(self):
        pass

    def test_labels(self):
        self.assertEqual(ControllerDevice._meta.get_field('name').verbose_name, "name")
        self.assertEqual(ControllerDevice._meta.get_field('registered_at').verbose_name, "registered at")
        self.assertEqual(ControllerDevice._meta.get_field('verified_at').verbose_name, "verified at")
        self.assertEqual(ControllerDevice._meta.get_field('verified_by').verbose_name, "verified by")
        self.assertEqual(ControllerDevice._meta.get_field('last_seen').verbose_name, "last seen")

    def test_serialize(self):
        pass

    def test_deserialize(self):
        pass


class StateTestCase(TestCase):
    def setUp(self):
        pass

    def test_labels(self):
        self.assertEqual(State._meta.get_field('device').verbose_name, "device")
        self.assertEqual(State._meta.get_field('name').verbose_name, "name")
        self.assertEqual(State._meta.get_field('value').verbose_name, "value")

    def test_serialize(self):
        pass

    def test_deserialize(self):
        pass


class ThingDeviceTestCase(TestCase):
    def setUp(self):
        pass

    def test_labels(self):
        self.assertEqual(ThingDevice._meta.get_field('name').verbose_name, "name")
        self.assertEqual(ThingDevice._meta.get_field('registered_at').verbose_name, "registered at")
        self.assertEqual(ThingDevice._meta.get_field('verified_at').verbose_name, "verified at")
        self.assertEqual(ThingDevice._meta.get_field('verified_by').verbose_name, "verified by")
        self.assertEqual(ThingDevice._meta.get_field('last_seen').verbose_name, "last seen")

    def test_serialize(self):
        pass

    def test_deserialize(self):
        pass


class FunctionTestCase(TestCase):
    def setUp(self):
        pass

    def test_labels(self):
        self.assertEqual(Function._meta.get_field('device').verbose_name, "device")
        self.assertEqual(Function._meta.get_field('name').verbose_name, "name")

    def test_serialize(self):
        pass

    def test_deserialize(self):
        pass


class ParameterTestCase(TestCase):
    def setUp(self):
        pass

    def test_labels(self):
        self.assertEqual(Parameter._meta.get_field('function').verbose_name, "function")
        self.assertEqual(Parameter._meta.get_field('order').verbose_name, "order")
        self.assertEqual(Parameter._meta.get_field('type').verbose_name, "type")

    def test_serialize(self):
        pass

    def test_deserialize(self):
        pass


class BehaviorTestCase(TestCase):
    def setUp(self):
        pass

    def test_labels(self):
        self.assertEqual(Behavior._meta.get_field('created_by').verbose_name, "created by")

    def test_serialize(self):
        pass

    def test_deserialize(self):
        pass


class TriggerTestCase(TestCase):
    def setUp(self):
        pass

    def test_labels(self):
        self.assertEqual(Trigger._meta.get_field('behavior').verbose_name, "behavior")

    def test_serialize(self):
        pass

    def test_deserialize(self):
        pass


class StateTriggerTestCase(TestCase):
    def setUp(self):
        pass

    def test_labels(self):
        self.assertEqual(StateTrigger._meta.get_field('state').verbose_name, "state")

    def test_serialize(self):
        pass

    def test_deserialize(self):
        pass


class DateTriggerTestCase(TestCase):
    def setUp(self):
        pass

    def test_labels(self):
        self.assertEqual(DateTrigger._meta.get_field('when').verbose_name, "when")

    def test_serialize(self):
        pass

    def test_deserialize(self):
        pass

