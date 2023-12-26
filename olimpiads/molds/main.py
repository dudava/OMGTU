import os
import func

paths = os.listdir("tests")
inputs = paths[:len(paths) // 2]
outputs = paths[len(paths) // 2:]

for _ in range(len(inputs)):
    with open(f"./tests/{inputs[_]}", mode="rt") as input_f:
        with open(f"./tests/{outputs[_]}", mode="rt") as output_f:
            def elements_match(list1, list2):
                for _ in range(len(list1)):
                    if list1[_] != list2[_]:
                        return False
                return True
            

            n = int(input_f.readline())
            default_details = []
            for i in range(n):
                default_details.append([int(q) for q in input_f.readline().split()])
            default_forms = []
            for i in range(n*2):
                default_forms.append([int(q) for q in input_f.readline().split()])

            
            correct_output = [tuple([int(i) for i in output_f.readline().split()]) for _ in range(n)]
            output = func.func(n, default_details, default_forms)
            if elements_match(output, correct_output):
                print("\033[92m" + f"Все верно для {_} теста: {output} = {correct_output}" + "\033[0m")
            else:
                print("\033[93m" + f"Ошибка в {_} тесте: {output} != {correct_output}" + "\033[0m")
                