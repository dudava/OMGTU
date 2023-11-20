import os

from func import func

paths = os.listdir("./tests")
inputs = paths[:8]
outputs = paths[8:]

for _ in range(len(inputs)):
    with open(f"./tests/{inputs[_]}") as input_f:
        with open(f"./tests/{outputs[_]}") as output_f:
            date_1 = input_f.readline().strip()
            date_2 = input_f.readline().strip()
            p = int(input_f.readline())
            result = func(date_1, date_2, p)
            correct_result = int(output_f.readline())

            if result == correct_result:
                print("Красава все верно")
            else:
                print(f"Не брат это не результат, {result} != {correct_result}")  


