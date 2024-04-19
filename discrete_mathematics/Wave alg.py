height = 11
width = 7
v = height * width + 1
end_coords = (10, 6)
field = [
    [v, v, v, v, v, v, v],
    [v, v, v, v, -1, v, v],
    [v, v, -1, v, -1, v, v],
    [0, v, -1, v, -1, v, v],
    [v, v, -1, v, v, v, v],
    [v, v, -1, v, v, v, v],
    [v, v, v, v, v, v, v],
    [v, v, v, v, -1, -1, -1],
    [v, -1, v, v, v, v, v],
    [v, -1, v, v, v, v, v],
    [v, -1, v, v, v, v, 'end'],
]

field.insert(0, [-1] * width)
field.append([-1] * width)
field = [[-1] + row + [-1] for row in field]


def walk_around(matrix, i, j, step):
    for _i in range(i - 1, i + 2):
        for _j in range(j - 1, j + 2):
            if matrix[_i][_j] == 'end':
                matrix[_i][_j] = step + 1
                return True
            if matrix[_i][_j] == -1:
                continue
            if step + 1 < matrix[_i][_j]:
                matrix[_i][_j] = step + 1


def ways_algorithm(field):
    matrix = field[::]
    for _ in range(v):
        for i in range(1, len(matrix) - 1):
            for j in range(1, len(matrix[i]) - 1):
                if matrix[i][j] == -1:
                    continue
                if matrix[i][j] == _:
                    is_ended = walk_around(matrix, i, j, _)
                    if is_ended:
                        return matrix


result_matrix = ways_algorithm(field)

for _ in result_matrix:
    print("\t".join([str(i) for i in _]))



def find_next_coords(matrix, current, current_coords):
    for _i in range(current_coords[0] - 1, current_coords[0] + 2):
        for _j in range(current_coords[1] - 1, current_coords[1] + 2):
            if result_matrix[_i][_j] == current - 1:
                current_coords = (_i, _j)
                return current_coords

path = []
path.insert(0, (end_coords[0] + 1, end_coords[1] + 1))
end = result_matrix[end_coords[0]][end_coords[1]]
current_coords = end_coords

for _ in range(end, -1, -1):
    current = _
    coords = find_next_coords(result_matrix, current, current_coords)
    path.insert(0, current_coords)
    current_coords = coords

print(path)

