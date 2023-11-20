import os
from func import func

paths = os.listdir("./tests")
half = len(paths) // 2
inputs = paths[:half]
outputs = paths[half:]

for _ in range(len(inputs)):
    with open(f"./tests/{inputs[_]}") as input_f:
        with open(f"./tests/{outputs[_]}") as output_f:
            C_start = [int(n) for n in input_f.readline().split(" ")[1:]][::-1]
            start_unhappy = sorted([int(n) for n in input_f.readline().split(" ")[1:]])
            C_end = [int(n) for n in input_f.readline().split(" ")[1:]][::-1]
            end_unhappy = sorted([int(n) for n in input_f.readline().split(" ")[1:]])
            start_amount = [int(n) for n in input_f.readline().split(" ")]
            correct_result = output_f.readline()

            result = func(C_start, start_unhappy, C_end, end_unhappy, start_amount)
            if result != correct_result:
                print(f"Неверно для {inputs[_]}, {result} != {correct_result}")
            else:
                print(f"Все верно для {inputs[_]}, {result} == {correct_result}")
