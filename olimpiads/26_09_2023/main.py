import os
from house import build_house

test_paths = os.listdir('tests')
input_paths = test_paths[:14]
output_paths = test_paths[14:]

for _ in range(len(input_paths)):
    with open(f'tests/{input_paths[_]}', mode='rt') as file:
        inp = file.readline().split()
        X, Y, L, C1, C2, C3, C4, C5, C6 = [int(_) for _ in inp]
        output = build_house(X, Y, L, C1, C2, C3, C4, C5, C6)
    with open(f'tests/{output_paths[_]}', mode='rt') as file:
        correct_output = int(file.readline())
    print(input_paths[_], output, correct_output)



