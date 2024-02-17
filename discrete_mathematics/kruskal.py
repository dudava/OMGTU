vs = {
    (1, 6): 1,
    (1, 4): 3,
    (1, 5): 6,
    (2, 6): 6,
    (1, 2): 4,
    (2, 4): 3,
    (2, 5): 7,
    (2, 7): 1,
    (2, 3): 2,
    (3, 5): 4,
    (3, 7): 2,
    (4, 6): 5,
    (4, 5): 1,
    (4, 7): 3,
    (5, 6): 3,
    (5, 7): 6,
    (6, 7): 7,
}

_vs = sorted(list(vs.keys()), key=lambda x: vs[x])
print(_vs)
classes = []


def check(_):
    _ = set(_)
    for vs_set in classes:
        if len(_ & vs_set) == 1:
            vs_set.update(_)
            for vs_set_2 in classes:
                if vs_set == vs_set_2:
                    continue
                if len(vs_set & vs_set_2) == 1:
                    vs_set.update(vs_set_2)
                    classes.remove(vs_set_2)
            return True
        if len(_ & vs_set) == 2:
            return False
    classes.append(_)
    return True


summ = 0
for _ in _vs:
    if check(_):
        summ += vs[_]

print(summ)