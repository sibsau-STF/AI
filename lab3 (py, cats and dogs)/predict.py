import os
import sys

import numpy as np
from keras.models import load_model
from keras.preprocessing import image as k_image

def norm_image(path, image_height=128, image_width=128):
    image = k_image.load_img(path, target_size=(image_height, image_width))
    image_arr = k_image.img_to_array(image) / 255.0
    return np.array([image_arr])

def predict_model(model, data):
    return model.predict(data)[0]

if __name__ == '__main__':
    model = load_model('recognizer')
    model.summary()
    print('######## Predict ########')
    correct = 0
    dataset = sys.argv[1:]
    if os.path.isdir(dataset[0]):
        dataset = os.listdir(dataset[0])
        dataset = [os.path.join(sys.argv[1], i) for i in dataset]
    for data in dataset:
        image = norm_image(data)
        predicted = predict_model(model, image)
        is_cat = predicted[0] > predicted[1]
        is_correct = is_cat and ('cat' in data.split('\\')[-1].split('.')) or not (is_cat or ('cat' in data.split('\\')[-1].split('.')))
        if is_correct:
            correct += 1
        print(data, ' - ', 'cat' if is_cat else 'dog', ' - ', is_correct)
    print(correct, '/', len(dataset))
    print(correct * 1.0 / len(dataset))
    os.system('pause')
