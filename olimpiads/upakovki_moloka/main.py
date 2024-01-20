import os
import func

paths = os.listdir("tests")
inputs = paths[:len(paths) // 2]
outputs = paths[len(paths) // 2:]

for _ in range(len(inputs)):
    with open(f"tests/{inputs[_]}") as input_f:
        with open(f"tests/{outputs[_]}") as output_f:
            N = int(input_f.readline())
            packets = []
            for n in range(N):
                packets.append([float(i) for i in input_f.readline().split()])
            output = func.func(packets)
            correct_output = [float(i) for i in output_f.readline().split()]
            if output == correct_output:
                print(f"Все верно для {inputs[_]}: {output} == {correct_output}")
            else:
                print(f"Ошибка в {inputs[_]}: {output} != {correct_output}")
