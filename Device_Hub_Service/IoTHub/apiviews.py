from django.http import HttpResponse
from rest_framework.response import Response
from rest_framework import status


def hello_world(request):
    return HttpResponse("Hello World!", status=status.HTTP_200_OK)