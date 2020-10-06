"""
Example of REST API written in Python and Flask;
May be deleted in production;
"""

from flask import Flask
from flask_restful import Api, Resource, reqparse
import random

APP = Flask(__name__)
API = Api(APP)

DATABASE = [{"id": 0, "name": "John"},
            {"id": 1, "name": "Mary"}]


class Quote(Resource):
    """
    Inherited from Resource class
    Handles methods: GET, POST
    """
    @staticmethod
    def get(index):
        """
        GET method
        :param index: index to take from database
        :return: tuple(data, status)
        """
        response = None
        if not DATABASE:
            return "Empty database", 404
        if index <= len(DATABASE) - 1:
            response = DATABASE[index]
        if not response:
            return "Data not found", 404
        return response

    @staticmethod
    def post(index):
        """
        :param index: integer
        :return: tuple(data to post, status)
        """
        parser = reqparse.RequestParser()
        parser.add_argument("name")
        params = parser.parse_args()
        element_exist_in_db = any(
            [element["id"] == index for element in DATABASE]
        )
        if element_exist_in_db:
            return f"Element with id {index} already exists", 400
        data_to_post = {
            "id": int(index),
            "name": params["name"]
        }
        DATABASE.append(data_to_post)
        return "Wrote: " + str(data_to_post), 201


API.add_resource(Quote, "/database", "/database/", "/database/<int:index>")
if __name__ == '__main__':
    APP.run(debug=True)
