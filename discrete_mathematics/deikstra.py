import collections

ribs = {
    (1, 2): 41,
    (1, 3): 80,
    (1, 4): 23,
    (1, 5): 32,
    (2, 3): 45,
    (2, 4): 12,
    (2, 5): 37,
    (3, 4): 50,
    (3, 5): 64,
    (4, 5): 67,
}
ribs.update({
    (key[1], key[0]): value for key, value in ribs.items()
})
vertex_ribs = collections.defaultdict(list)
for key, value in ribs.items():
    vertex_ribs[key[0]].append((key[1], value))

out_n = 4
in_n = 5


def deikstra_func(summ, current_vertex, end_vertex, pointed_vertices, min_lengths):
    pointed_vertices.add(current_vertex)
    if current_vertex == end_vertex:
        return min_lengths[end_vertex]
    choice_vertex = []
    print(pointed_vertices)
    for in_vertex, length in vertex_ribs[current_vertex]:
        if in_vertex in pointed_vertices:
            continue

        choice_vertex.append((in_vertex, length))
        
        if in_vertex not in min_lengths:
            min_lengths[in_vertex] = length
        else:
            total_length = summ + length
            if total_length < min_lengths[in_vertex]:
                min_lengths[in_vertex] = total_length
    min_vertex = min(choice_vertex, key=lambda x: x[1])
    return deikstra_func(summ + min_vertex[1], min_vertex[0], end_vertex, pointed_vertices, min_lengths)
        

result = deikstra_func(0, out_n, in_n, set(), {})
print(f"Минимальный путь из {out_n} в {in_n}: {result}")
