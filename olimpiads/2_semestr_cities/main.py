import os


def func(cities):
    def find_doubles(string):
        doubles = set()
        for i in range(len(string) - 1):
            if string[i] == string[i + 1]:
                doubles.add(string[i:i + 2])
        return doubles

    def rotate_palindrome(string, index):
        left = string[:index]
        right = string[index:]
        return right + left

    words = cities    

    for i in range(0, len(words)):
        words[i] = words[i][0 ] +words[i][-1]
    chains = [0 for i in range(0, len(words))]
    action_global = True
    while action_global == True:
        action_global = False
        for i in range(0, len(words)):
            action = True
            while action == True:
                action = False
                if words[i] != "":
                    for w in range(0, len(words)):
                        if words[w] != "":
                            if (w != i) and (words[i][-1] == words[w][0]):
                                words[i] = words[i]+words[w]
                                words[w] = ""
                                chains[i] = chains[i] + 1 + chains[w]
                                action = True
                                action_global = True
                                continue
                            if (w != i) and (words[w][-1] == words[i][0]):
                                words[i] = words[w]+words[i]
                                words[w] = ""
                                chains[i] = chains[i] + 1 + chains[w]
                                action = True
                                action_global = True
                                continue
                            if ((len(words[i]) > 2) and (len(words[w]) > 2) and (i != w)):
                                doubles_in_i = find_doubles(words[i])
                                for d in doubles_in_i:
                                    if d in words[w]:
                                        words[w] = rotate_palindrome(words[w], words[w].find(d)+1)
                                        break

                    for w in range(0, len(words)):
                        if words[w] != "":
                            if ((len(words[i]) > 2) and (len(words[w]) > 2) and (i != w) and (words[w][0]+words[w][-1] in words[i])):
                                pos = words[i].find(words[w][0]+words[w][-1])
                                words[i] = words[i][:pos]+words[w]+words[i][pos:]
                                break
    chains = [c+1 for c in chains]
    out = []
    for i in range(0, len(words)):
        if words[i] != '':
            out.append(chains[i])
    out_str = str(len(out))
    out.sort(reverse=True)
    for e in out:
        out_str = out_str+"\n"+str(e)

    return out_str


paths = os.listdir("tests")
inputs = paths[:len(paths) // 2]
outputs = paths[len(paths) // 2:]

for _ in range(len(inputs)):
    with open(f"./tests/{inputs[_]}", mode="rt") as input_f:
        with open(f"./tests/{outputs[_]}", mode="rt") as output_f:
            input_cities = [line.strip() for line in input_f.readlines()]
            output = func(input_cities)
            correct_output = output_f.read()
            if output != correct_output:
                print("\033[93m" + f"Ошибка в {_} тесте" + "\033[0m")
            else:
                print(f'Тест {_}: OK')