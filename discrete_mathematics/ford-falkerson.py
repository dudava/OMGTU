import collections
import copy

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

start_v = 1
end_v = 5

vertices = collections.defaultdict(list)

for _ in net:
    vertices[_[0]].append(_[1])

def ps_to_vertices(ps):
    if not ps:
        return []
    unavaible_vertices = [ps[0][0]]
    for _ in ps:
        unavaible_vertices.append(_[1])
    return unavaible_vertices


def invert_flow(vertex, returned_ps):
    inverted_net = {}
    for k, v in net.items():
        inverted_net[k[1], k[0]] = v
    ps = returned_ps
    inv_vertices_c = copy.deepcopy(vertices)
    for _ in net:
        inv_vertices_c[_[1]].append(_[0])

    while vertex in inv_vertices_c:
        if vertex == end_v: break
        max_p = 0
        selected_v = None
        for _ in inv_vertices_c[vertex]:
            if (vertex, _) in net and net[(vertex, _)][0] > max_p and _ not in ps_to_vertices(ps):
                max_p = net[(vertex, _)][0]
                selected_v = _
            elif (vertex, _) in inverted_net and inverted_net[(vertex, _)][1] > max_p and _ not in ps_to_vertices(ps):
                max_p = inverted_net[(vertex, _)][1]
                selected_v = _
        if selected_v is None:
            last = ps.pop()
            block_v = last[1]
            for key, v in inv_vertices_c.items():
                if block_v in v:
                    v.remove(block_v)
            vertex = last[0]
        else:
            ps.append((vertex, selected_v))
            vertex = selected_v
    all_p = [net[_][0] for _ in ps if _ in net] + [inverted_net[_][1] for _ in ps if _ in inverted_net]
    min_p = min(all_p)
    for _ in ps:
        if _ in inverted_net:
            orig = inverted_net[_]
            net[_[1], _[0]] = [orig[0] + min_p, orig[1] - min_p]
        elif _ in net:
            orig = net[_]
            net[_] = [orig[0] - min_p, orig[1] + min_p]


def check_block(v, vs):
    check = all([net[(v, _)][0] == 0 for _ in vs])
    return check


while not check_block(start_v, vertices[start_v]):
    vertex = start_v
    ps = []
    returned_ps = []
    invert_v = None
    flag = False
    vertices_c = copy.deepcopy(vertices)
    while vertex in vertices_c:
        max_p = 0
        selected_v = None
        for _ in vertices_c[vertex]:
            if net[(vertex, _)][0] > max_p and _ not in ps_to_vertices(ps):
                max_p = net[(vertex, _)][0]
                selected_v = _
        if selected_v is None:
            block_v = ps[-1][1]
            for key, v in vertices_c.items():
                if block_v in v:
                    v.remove(block_v)
            if not invert_v:
                invert_v = block_v
                returned_ps = ps.copy()
            last = ps.pop()
            is_blocked = check_block(start_v, vertices_c[start_v])
            if last[0] == start_v and is_blocked and invert_v:
                invert_flow(invert_v, returned_ps)
                flag = True
                break
            vertex = last[0]
        else:
            ps.append((vertex, selected_v))
            vertex = selected_v
    if not flag:
        min_p = min([net[_][0] for _ in ps])
        for _ in ps:
            orig = net[_]
            net[_] = [orig[0] - min_p, orig[1] + min_p]
    print(net)

print(f'S: {sum([net[start_v, _][1] for _ in vertices[start_v]])}')