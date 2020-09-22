import os
import random

import numpy as np
from keras.models import load_model
from keras.preprocessing import image as k_image

def rand_dataset(dataset_x=[], dataset_y=[], seed=42):
    random.seed(seed)
    random.shuffle(dataset_x)
    random.seed(seed)
    random.shuffle(dataset_y)
    return dataset_x, dataset_y

def load_dataset(dataset_dir='.\\train', trainset_p=0.75, image_height=128, image_width=128, image_depth=3):
    list_dir = os.listdir(dataset_dir)
    random.shuffle(list_dir)
    dataset_x = [list(), list()]
    for image_name in list_dir:
        image_path = os.path.join(dataset_dir, image_name)
        image = k_image.load_img(image_path, target_size=(image_height, image_width))
        image_arr = k_image.img_to_array(image) / 255.0
        if image_name.split('.')[0] == 'cat':
            dataset_x[0].append(image_arr)
            # dataset_x[0].append(image_name)
        else:
            dataset_x[1].append(image_arr)
            # dataset_x[1].append(image_name)
    # rand_dataset(dataset_x=dataset_x[0])
    # rand_dataset(dataset_x=dataset_x[1])
    trainset_x = dataset_x[0][:int(len(dataset_x[0]) * trainset_p)] + dataset_x[1][:int(len(dataset_x[1]) * trainset_p)]
    trainset_y = \
        [[1, 0] for i in range(int(len(dataset_x[0]) * trainset_p))] + \
        [[0, 1] for i in range(int(len(dataset_x[1]) * trainset_p))]
    trainset_x, trainset_y = rand_dataset(trainset_x, trainset_y)
    testset_x = dataset_x[0][int(len(dataset_x[0]) * trainset_p):] + dataset_x[1][int(len(dataset_x[1]) * trainset_p):]
    testset_y = \
        [[1, 0] for i in range(len(dataset_x[0]) - int(len(dataset_x[0]) * trainset_p))] + \
        [[0, 1] for i in range(len(dataset_x[1]) - int(len(dataset_x[1]) * trainset_p))]
    testset_x, testset_y = rand_dataset(testset_x, testset_y)
    # print(trainset_x, trainset_y)
    # print(testset_x, testset_y)
    return (np.array(trainset_x), np.array(trainset_y)), (np.array(testset_x), np.array(testset_y))

def train_model(model, epochs, cycles, trainset, testset):
    for i in range(cycles):
        print('########////{0}\\\\\\\\########'.format(i))
        history = model.fit(trainset[0], trainset[1], 
        validation_data=(testset[0], testset[1]), 
        steps_per_epoch=len(trainset[0]),
        epochs=epochs)
        model.save('recognizer')
        print('########\\\\\\\\{0}////########'.format(i))
    return history

if __name__ == '__main__':
    model = load_model('recognizer')
    model.summary()
    trainset, testset = load_dataset()
    history = train_model(model, int(input('Введите количество эпох обучения: ')), int(input('Введите количество циклов обучения: ')), trainset, testset)
    