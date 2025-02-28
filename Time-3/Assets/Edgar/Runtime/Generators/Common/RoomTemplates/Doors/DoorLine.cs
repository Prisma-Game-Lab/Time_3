﻿using System;
using Edgar.Geometry;
using Edgar.GraphBasedGenerator.Common.Doors;
using Edgar.GraphBasedGenerator.Grid2D;
using UnityEngine;

namespace Edgar.Unity
{
    [Serializable]
    public class DoorLine
    {
        public Vector3Int From;

        public Vector3Int To;

        public int Length;

        public DoorLineGrid2D ToInternal()
        {
            var line = new OrthogonalLineGrid2D(From.ToCustomIntVector2(), To.ToCustomIntVector2());

            if (Length > 1)
            {
                line = line.Shrink(0, Length - 1);
            }
            
            return new DoorLineGrid2D(
                line,
                Length - 1,
                null,
                DoorType.Undirected);
        }

        #region Equals

        protected bool Equals(DoorLine other)
        {
            return From.Equals(other.From) && To.Equals(other.To) && Length == other.Length;
        }

        public override bool Equals(object obj)
        {
            if (ReferenceEquals(null, obj)) return false;
            if (ReferenceEquals(this, obj)) return true;
            if (obj.GetType() != this.GetType()) return false;
            return Equals((DoorLine)obj);
        }

        public override int GetHashCode()
        {
            unchecked
            {
                var hashCode = From.GetHashCode();
                hashCode = (hashCode * 397) ^ To.GetHashCode();
                hashCode = (hashCode * 397) ^ Length;
                return hashCode;
            }
        }

        public static bool operator ==(DoorLine left, DoorLine right)
        {
            return Equals(left, right);
        }

        public static bool operator !=(DoorLine left, DoorLine right)
        {
            return !Equals(left, right);
        }

        #endregion
    }
}