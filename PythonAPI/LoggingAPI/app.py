from flask import Flask
from flask_restful import Api, Resource, reqparse
from PythonAPI.LoggingAPI.LDAP_API import LDAP

APP = Flask(__name__)
API = Api(APP)

LDAP_PROCESSOR = LDAP()


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
        LDAP_PROCESSOR.get_data()

    @staticmethod
    def post(login, password):
        """
        :param login: LDAP login
        :param password: LDAP password
        :return:
        """
        parser = reqparse.RequestParser()
        parser.add_argument("name")
        # params = parser.parse_args()
        LDAP_PROCESSOR.login(login, password)


API.add_resource(Quote, "/login", "/login/", "/login/<str:login>/<str:password>")
if __name__ == '__main__':
    APP.run(debug=True)
