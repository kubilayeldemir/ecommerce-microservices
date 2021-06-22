import json
from objdict import ObjDict
import random
import requests
import pandas as pd

Flipkart_data = pd.read_csv("../products-dataset-migrator/input/flipkart_com-ecommerce_sample.csv")

Flipkart_data.info()

counter = 0
success = 0
error = 0
number_of_objects_per_request = 10

product_list = []
data = ObjDict()
for x in range(len(Flipkart_data)):
    try:
        data.images = json.loads(Flipkart_data["image"][x])
        data.name = Flipkart_data["product_name"][x]
        brand = Flipkart_data["brand"][x]
        if type(brand) == float:
            data.brand = "Unknown"
        else:
            data.brand = brand

        data.description = Flipkart_data["description"][x]
        data.retailPrice = int(Flipkart_data["retail_price"][x]) * 0.013
        data.unique_id = Flipkart_data["uniq_id"][x]
        data.discountedPrice = int(Flipkart_data["discounted_price"][x]) * 0.013
        categoryString = json.loads(Flipkart_data["product_category_tree"][x])[0]
        categoryList = categoryString.split(">>")
        data.category = categoryList
        data.stock = random.randint(10, 100)
        data.url = Flipkart_data["product_url"][x]
        product_list.append(data)
        data = ObjDict()
        counter += 1

        if counter == number_of_objects_per_request:
            json_list = json.dumps(product_list)
            headers = {'Content-type': 'application/json', 'Accept': 'application/json'}
            url = 'http://localhost:8080/api/products'

            x = requests.post(url, data=json_list, headers=headers)

            print("Request Status:" + x.text)
            product_list.clear()
            json_list = ""
            counter = 0
        success += 1
    except:
        print("Error, Couldn't create an object")
        error += 1


print("succes:" + str(success))
print("error" + str(error))
