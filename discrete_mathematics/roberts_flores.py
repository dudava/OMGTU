matrix = [
    [0, 1, 1, 1, 0, 0, 0],
    [1, 0, 1, 0, 1, 0, 1],
    [1, 1, 0, 1, 1, 1, 1],
    [1, 0, 1, 0, 1, 1, 1],
    [0, 1, 1, 1, 0, 1, 0],
    [0, 0, 1, 1, 1, 0, 1],
    [0, 1, 1, 1, 0, 1, 0],
]


def get_vertecies(vert):
    return [_ for _ in range(len(matrix[vert])) if matrix[vert][_]]


def path(cur_vertex, visited):
    ginger = get_vertecies(cur_vertex)
    # print(cur_vertex, ginger, visited)
    # print(len(matrix))
    if len(visited) + 1 == len(matrix):
        result = visited + [cur_vertex]
        print([_ + 1 for _ in result], "цикл" if matrix[result[-1]][0] == 1 else "путь")

    for _ in ginger:
        if _ not in visited:
            path(_, visited + [cur_vertex])


cur_vertex = 0
path(0, [])
