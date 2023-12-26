import os
import func

paths = os.listdir("tests")
inputs = paths[:len(paths) // 2]
outputs = paths[len(paths) // 2:]

for _ in range(len(inputs)):
    with open(f"./tests/{inputs[_]}", mode="rt") as input_f:
        with open(f"./tests/{outputs[_]}", mode="rt") as output_f:
            a,b,c = [int(i) for i in input_f.readline().split(" ")]
            s1,s2,s3 = [int(i) for i in input_f.readline().split(" ")]
            m1,m2,m3 = [int(i) for i in input_f.readline().split(" ")]
            correct_output = output_f.readline()
            output = func.func(a, b, c, s1, s2, s3, m1, m2, m3)
            if output == correct_output:
                print("\033[92m" + f"Все верно для {_} теста: {output} = {correct_output}" + "\033[0m")
            if output != correct_output:
                print("\033[93m" + f"Ошибка в {_} тесте: {output} != {correct_output}" + "\033[0m")
                