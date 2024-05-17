import collections

net = {
    (1, 4): [10, 0],
    (1, 3): [30, 0],
    (1, 2): [20, 0],
    (2, 3): [40, 0],
    (2, 5): [30, 0],
    (3, 4): [10, 0],
    (3, 5): [20, 0],
    (4, 5): [20, 0],
}

vertices = collections.defaultdict(list)

for _ in net:
    vertices[_[0]].append(_[1])

print(vertices)


def iteration(vertex, ps):
    for i in range(5):
        max_p = 0
        selected_v = None
        if vertex not in vertices:
            print(ps)
            return

        iteration(selected_v, ps)


# iteration(1, [])

for i in range(5):
    vertex = 1
    ps = []
    vertices_c = vertices.copy()
    print(vertices_c)
    while vertex in vertices_c:
        max_p = 0
        selected_v = None
        for _ in vertices_c[vertex]:
            if net[(vertex, _)][0] > max_p:
                max_p = net[(vertex, _)][0]
                selected_v = _
        if selected_v == None:
            last = ps.pop()
            block_v = last[1]
            for key, v in vertices_c.items():
                if block_v in v:
                    v.remove(block_v)
            vertex = last[0]
            print(net)
        else:
            ps.append((vertex, selected_v))
            vertex = selected_v
    min_p = min([net[_][0] for _ in ps])
    for _ in ps:
        orig = net[_]
        net[_] = [orig[0] - min_p, orig[1] + min_p]
    print(ps)
