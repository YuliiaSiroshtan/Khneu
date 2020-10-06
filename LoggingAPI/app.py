from flask import Flask
from flask_restful import Api, Resource, reqparse
import random

APP = Flask(__name__)
API = Api(APP)


class Quote(Resource):
    """
    Inherited from Resource class
    Handles methods: GET, POST
    """

    @staticmethod
    def get():
        """
        GET method
        """
        pass

    @staticmethod
    def post(login, password):
        """
        :param login: LDAP login
        :param password: LDAP password
        :return:
        """
        parser = reqparse.RequestParser()
        parser.add_argument("name")
        params = parser.parse_args()


API.add_resource(Quote, "/login", "/login/", "/login/<str:login>/<str:password>")
if __name__ == '__main__':
    APP.run(debug=True)
