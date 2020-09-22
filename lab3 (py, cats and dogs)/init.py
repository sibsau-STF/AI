from keras.models import Sequential
from keras.layers.convolutional import Conv2D
from keras.layers.convolutional import MaxPooling2D
from keras.layers.core import Flatten
from keras.layers.core import Dropout
from keras.layers.core import Dense
from keras.optimizers import SGD

def init_model(image_height=128, image_width=128, image_depth=3):
    model = Sequential([
        Conv2D(filters=32, kernel_size=(3, 3), padding='valid', input_shape=(image_height, image_width, image_depth), activation='relu'),
        MaxPooling2D(pool_size=(2, 2)),
        Conv2D(filters=64, kernel_size=(3, 3), padding='valid', activation='relu'),
        MaxPooling2D(pool_size=(2, 2)),
        Conv2D(filters=128, kernel_size=(3, 3), padding='valid', activation='relu'),
        MaxPooling2D(pool_size=(2, 2)),
        Conv2D(filters=128, kernel_size=(3, 3), padding='valid', activation='relu'),
        Dropout(0.3),
        Flatten(),
        Dense(units=256, activation='relu'),
        Dropout(0.001),
        Dense(units=128, activation='relu'),
        Dense(units=2, activation='softmax')
    ])
    return model

if __name__ == '__main__':
    model = init_model()

    model.summary()

    opt = SGD(
        learning_rate=0.02,
        decay=0.005
    )
    model.compile(
        loss='categorical_crossentropy',
        optimizer=opt,
        metrics=['accuracy']
    )
    model.save('recognizer')
