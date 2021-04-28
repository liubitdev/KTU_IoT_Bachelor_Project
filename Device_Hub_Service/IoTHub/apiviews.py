from django.http import HttpResponse
from django.shortcuts import render
from django.views import View
from rest_framework.response import Response
from rest_framework import status


def hello_world(request):
    return HttpResponse("Hello World!", status=status.HTTP_200_OK)
    
# class Index(View):
    # template = 'index.html'

    # def get(self, request):
        # return render(request, self.template)