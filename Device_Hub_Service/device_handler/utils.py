from iot_hub.models import \
    ThingDevice,\
    ControllerDevice,\
    State,\
    Function,\
    Parameter

def registerDevice(content):
    """
    Example JSON of a Thing-type device wanting to register.
    {
      "register": true,
      "device": "controller",
      "name": "deviceName",
      "states": [
        {
          "name": "State1",
          "value": "Open"
        },
        {
          "name": "State2",
          "value": "Closed"
        }]
    }
    """
    if content['device'] == 'controller':
        new_controller = ControllerDevice(
            name=content['name']
        )
        new_controller.save()
        for state in content['states']:
            new_state = State(
                device=new_controller,
                name=state['name'],
                value=state['value']
            )
            new_state.save()
        return new_controller
    """
    Example JSON of a Controller-type device wanting to register.
    {
      "register": true,
      "device": "thing",
      "name": "deviceName",
      "functions": [
        {
          "name": "FunctionOne",
          "parameters": [
            {
              "type": "int"
            },
            {
              "type": "string"
            }]
        },
        {
          "name": "FunctionTwo",
          "parameters": []
        }]
    }
    """
    if content['device'] == 'thing':
        new_thing = ThingDevice(
            name=content['name']
        )
        new_thing.save()
        for function in content['functions']:
            new_function = Function(
                device=new_thing,
                name=function['name']
            )
            new_function.save()
            for num, parameter in enumerate(function['parameters']):
                new_parameter = Parameter(
                    function=new_function,
                    order=num,
                    type=parameter['type']
                )
                new_parameter.save()
        return new_thing
