import os
from func import func

paths = os.listdir("./tests")
inputs = paths[:10]
outputs = paths[10:]

for _ in range(len(inputs)):
    with open(f"./tests/{inputs[_]}") as input_f:
        with open(f"./tests/{outputs[_]}") as output_f:
            N = int(input_f.readline())
            correct_result = int(output_f.readline())

            result = func(N)
            if result != correct_result:
                print(f"Неверно для {N}, {result} != {correct_result}")
            else:
                print(f"Все верно для {N}, {result} == {correct_result}")
