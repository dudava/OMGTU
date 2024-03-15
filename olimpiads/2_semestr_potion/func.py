import re

actions = {
    "MIX": "MX",
    "WATER": "WT",
    "DUST": "DT",
    "FIRE": "FR",
}

def func(commands):
    order = {}
    for _ in range(len(commands)):
        command = commands[_].strip().split(" ")
        word = command[0]
        ingredients = command[1:]
        for i in range(len(ingredients)):
            ingredient = ingredients[i]
            if ingredient.isdigit() and int(ingredient) in order:
                
                ingredients[i] = order[int(ingredient)]
        # print(ingredients)
        # print((actions[word], "".join(ingredients), actions[word][::-1]))
        expression = (
            "%s%s%s" % (actions[word], "".join(ingredients), actions[word][::-1])
        )
        order[_ + 1] = expression
        # print(order)
    final_expression = order[_ + 1]
    return final_expression



