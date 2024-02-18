import collections
import functools

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

vs_init = collections.defaultdict(list)
for key, value in vs.items():
    vs_init[key[0]].append({"v": key[1], "len": value})
    vs_init[key[1]].append({"v": key[0], "len": value})
# vs_init = {key: sorted(value, key=lambda v: v["len"]) for key, value in vs_init.items()}

ost_tree = []
summ = 0
ost_tree.append(list(vs_init)[0])
while len(ost_tree) != len(vs_init):
    all_ribs = sorted(
        functools.reduce(
            lambda prev_l, cur_l: prev_l + cur_l,
            [vs_init[key] for key in ost_tree],
        ),
        key=lambda v: v["len"],
    )
    for rib in all_ribs:
        if rib["v"] not in ost_tree:
            print(ost_tree)
            ost_tree.append(rib["v"])
            summ += rib["len"]
            break

print(ost_tree)
print(summ)