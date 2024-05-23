import os


def gears_func(gears_dict, gears_conn, result_gears_conn, rotation_dir):
    rotation_dirs = {result_gears_conn[0]: rotation_dir}
    rotation_speeds = {result_gears_conn[0]: 1}
    for i in range(100):
        for conn in gears_conn:
            f_gear = conn[0]
            s_gear = conn[1]
            if f_gear in rotation_dirs:
                if s_gear in rotation_dirs:
                    if rotation_dirs[f_gear] == rotation_dirs[s_gear]:
                        return -1
                else:
                    rotation_dirs[s_gear] = -rotation_dirs[f_gear]
                    rotation_speeds[s_gear] = rotation_speeds[f_gear] * (gears_dict[f_gear] / gears_dict[s_gear])
            elif s_gear in rotation_dirs:
                if f_gear in rotation_dirs:
                    if rotation_dirs[f_gear] == rotation_dirs[s_gear]:
                        return -1
                else:
                    rotation_dirs[f_gear] = -rotation_dirs[s_gear]
                    rotation_speeds[f_gear] = rotation_speeds[s_gear] * (gears_dict[s_gear] / gears_dict[f_gear])
    return rotation_dirs[result_gears_conn[1]], round(rotation_speeds[result_gears_conn[1]], 3)


paths = os.listdir('tests')
inputs = paths[:len(paths) // 2]
outputs = paths[len(paths) // 2:]

for с in range(0, len(paths) // 2):
    with open(f'tests/{inputs[с]}') as input_f:
        with open(f'tests/{outputs[с]}') as output_f:
            N, M = [int(_) for _ in input_f.readline().split()]
            gears_dict = {}
            for _ in range(N):
                i, z = [int(_) for _ in input_f.readline().split()]
                gears_dict[i] = z
            gears_conn = []
            for _ in range(M):
                gears_conn.append([int(_) for _ in input_f.readline().split()])
            result_gears_conn = [int(_) for _ in input_f.readline().split()]
            rotation_dir = int(input_f.readline())

            result = gears_func(gears_dict, gears_conn, result_gears_conn, rotation_dir)
            is_possible = int(output_f.readline())
            if is_possible == -1:
                assert result == -1
            else:
                correct_direction = int(output_f.readline())
                correct_speed = float(output_f.readline())
                assert result[0] == correct_direction
                assert result[1] == correct_speed
            print(f'Тест {inputs[с]} прошел')