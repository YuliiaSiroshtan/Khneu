import requests
import sys

INDEX = sys.argv[1]
NAME_TO_WRITE = sys.argv[2]
url = 'http://127.0.0.1:5000/database/' + str(INDEX)
payload = {
    "id": INDEX,
    "name": NAME_TO_WRITE
}
if __name__ == "__main__":
    r = requests.post(url, data=payload)
    print(r.json())
    print("Status code %s" % r.status_code)
