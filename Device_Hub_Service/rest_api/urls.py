from rest_framework import routers
from . import apiviews

router = routers.DefaultRouter()
router.register(r'iotdevice', apiviews.IoTDeviceViewSet, basename='iot_device')
router.register(r'controller', apiviews.ControllerDeviceViewSet, basename='controller')
router.register(r'state', apiviews.StateViewSet, basename='state')
router.register(r'thing', apiviews.ThingDeviceViewSet, basename='thing')
router.register(r'function', apiviews.FunctionViewSet, basename='function')
router.register(r'parameter', apiviews.ParameterViewSet, basename='parameter')
router.register(r'behavior', apiviews.BehaviorViewSet, basename='behavior')
router.register(r'call', apiviews.CallViewSet, basename='call')
router.register(r'callparam', apiviews.CallParameterViewSet, basename='callparam')
router.register(r'statetriggerspecific', apiviews.StateTriggerSpecificViewSet, basename='statetriggerspecific')
router.register(r'statetriggerrange', apiviews.StateTriggerRangeViewSet, basename='statetriggerrange')
router.register(r'datetrigger', apiviews.DateTriggerViewSet, basename='datetrigger')
urlpatterns = router.get_urls()
