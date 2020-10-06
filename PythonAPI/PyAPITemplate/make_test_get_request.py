import requests
import sys

INDEX = sys.argv[1]
url = 'http://127.0.0.1:5000/database/' + str(INDEX)
if __name__ == "__main__":
    r = requests.get(url)
    print(r.json())
    print("Status code %s" % r.status_code)
