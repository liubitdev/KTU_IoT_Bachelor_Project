from rest_framework import routers
from . import apiviews

router = routers.DefaultRouter()
router.register(r'controllers', apiviews.ControllerDeviceViewSet, basename='controller')
router.register(r'states', apiviews.StateViewSet, basename='state')
router.register(r'things', apiviews.ThingDeviceViewSet, basename='thing')
router.register(r'functions', apiviews.FunctionViewSet, basename='function')
router.register(r'parameters', apiviews.ParameterViewSet, basename='parameter')
router.register(r'behaviors', apiviews.BehaviorViewSet, basename='behavior')
router.register(r'statetriggers', apiviews.StateTriggerViewSet, basename='statetrigger')
router.register(r'datetriggers', apiviews.DateTriggerViewSet, basename='datetrigger')

urlpatterns = router.get_urls()
