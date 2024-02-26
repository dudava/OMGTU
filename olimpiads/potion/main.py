import os
import func

paths = os.listdir("./tests/")
print(paths)
inputs = paths[:len(paths) // 2]
outputs = paths[len(paths) // 2:]

for _ in range(len(inputs)):
    with open(f"./tests/{inputs[_]}", "rt") as input_f:
        with open(f"./tests/{outputs[_]}", "rt") as output_f:
            commands = input_f.readlines()
            output = func.func(commands)
            req_output = output_f.readline()
            if (output != req_output):
                print(f"Неправильный вывод: {output} != {req_output}")
            # else:
            #     print(f"Все правильно: {output} == {req_output}")